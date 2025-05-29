using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Project_KTMH
{
    public class Attendance
    {

        private TimeSpan checkInTime;
        private TimeSpan checkOutTime;
        private string status;

        private TimeSpan defaultTimeIn = new TimeSpan(9, 0, 0);
        private TimeSpan defaultTimeOut = new TimeSpan(17, 0, 0);
        private bool checkIn = false;
        private bool checkOut = false;
        private TimeSpan otTime;
        private DateTime date;
        private int workingDay;

        Dictionary<string, List<Attendance>> attendanceRecords = new Dictionary<string, List<Attendance>>();
        //string đại diện cho employeeId

        public TimeSpan OtTime { get => otTime; }
        public bool CheckIn { get => checkIn; }
        public bool CheckOut { get => checkOut; }
        public string Status { get => status; set => status = value; }
        public DateTime Date { get => date; }

        public Attendance(DateTime date, TimeSpan checkInTime, bool checkIn, string status, TimeSpan checkOutTime, bool checkOut, TimeSpan otTime)
        {
            this.date = date.Date;
            this.checkInTime = checkInTime;
            this.checkIn = checkIn;
            this.Status = status;
            this.checkOutTime = checkOutTime;
            this.checkOut = checkOut;
            this.otTime = otTime;
        }

        public string TimeIn(TimeSpan checkInTime)
        {
            if (checkInTime >= defaultTimeIn && checkInTime <= new TimeSpan(9, 15, 0))
            {
                checkIn = true;
                status = "normal";
            }
            else if (checkInTime > new TimeSpan(9, 15, 0))
            {
                checkIn = true;
                status = "late";
            }
            else
            {
                status = "error";
            }    
            return status;
        }

        public void TimeOut(TimeSpan checkOutTime)
        {
            if (checkOutTime >= defaultTimeOut && checkOutTime <= new TimeSpan(18, 0, 0))
            {
                checkOut = true;
            }
            else if (checkOutTime > new TimeSpan(18, 30, 0))
            {
                TimeSpan newOtTime = new TimeSpan(0, 0, 0);
                checkOut = true;
                TimeSpan otduration = checkOutTime - new TimeSpan(18, 30, 0);

                if (otduration > newOtTime)
                {
                    otTime += new TimeSpan(otduration.Hours, 0, 0);
                }
            }
        }

        public int CountDay(string employeeID)
        {
            foreach ((Employee, Payroll) e in EmployeeList.emp)
            {

                if (e.Item1.EmployeeID1 == employeeID)
                {
                    List<Attendance> attendances = e.Item1.attendances;

                    foreach (Attendance attendance in attendances)
                    {
                        if (attendance.checkOut && attendance.checkIn)
                        {
                            attendance.workingDay++;
                        }
                    }
                }
            }
            return workingDay;
        }

        //tạo bảng điểm danh mới mỗi ngày cho từng người 
        public void CreateDailyRecord(List<Employee> employees)
        {
            DateTime today = DateTime.Today;

            foreach (Employee employee in employees)
            {
                //List<Attendance> attendances = attendanceRecords[employee.EmployeeID1];

                bool hasrecord = false;

                for (int i = 0; i < employee.attendances.Count; i++)
                {
                    if (employee.attendances[i].date.Date == today)
                    {
                        hasrecord = true;
                        break;
                    }
                }

                if (!hasrecord)
                {
                    Attendance attendance = new Attendance(date, TimeSpan.MinValue, false, "none", TimeSpan.MinValue, false, default);
                    attendance.checkInTime = TimeSpan.MinValue;
                    attendance.checkOutTime = TimeSpan.MinValue;

                    employee.attendances.Add(attendance);
                    //attendanceRecords[employee.EmployeeID1].Add(attendance);
                }
            }
        }

        //update khi người dùng checkin và checkout
        //kiểm tra mã nhân viên khi người dùng nhập vào 
        public void UpdateRecord(string employeeID, string action)
        {
            //List<Attendance> attendances = attendanceRecords[employeeID];
            DateTime today = DateTime.Today;
            DateTime now = DateTime.Now;
            foreach ((Employee, Payroll) e in EmployeeList.emp)
            {
                if (e.Item1.EmployeeID1 == employeeID)
                {
                    foreach (Attendance attendance in e.Item1.attendances)
                    {
                        

                            if (action == "CheckIn")
                            {
                                attendance.checkInTime = now.TimeOfDay;
                                
                                attendance.status = attendance.TimeIn(attendance.checkInTime);
                                attendance.checkIn = true;
                                

                            }

                            if (action == "CheckOut")
                            {
                                attendance.checkOutTime = now.TimeOfDay;
                                attendance.TimeOut(attendance.checkOutTime);
                                attendance.checkOut = true;
                            }

                        

                    }
                }
            }
        }
    }
}