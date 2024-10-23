using System;
using System.Collections.Generic;

namespace _Project__Atendence_Program
{
    public class Attendance
    {
        private int attendanceID;
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
        public string Status { get => status; }

        public Attendance(DateTime date, TimeSpan checkInTime, bool checkIn, string status, TimeSpan checkOutTime, bool checkOut, TimeSpan otTime)
        {
            this.date = date;
            this.checkInTime = checkInTime;
            this.checkIn = checkIn;
            this.status = status;
            this.checkOutTime = checkOutTime;
            this.checkOut = checkOut;
            this.otTime = otTime;
        }

        public void TimeIn(TimeSpan checkInTime)
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
        }

        public void TimeOut(TimeSpan checkOutTime)
        {
            if (checkOutTime >= defaultTimeOut && checkOutTime <= new TimeSpan(18, 0, 0))
            {
                checkOut = true;
            }
            else if (checkOutTime > new TimeSpan(18, 0, 0))
            {
                TimeSpan newOtTime;
                checkOut = true;
                newOtTime = checkOutTime - new TimeSpan(18, 0, 0);
                otTime += newOtTime;
            }
        }

        public int CountDay(string employeeID)
        {
            if (attendanceRecords.ContainsKey(employeeID))
            {
                List<Attendance> attendances = attendanceRecords[employeeID];

                foreach (Attendance attendance in attendances)
                {
                    if (attendance.checkOut && attendance.checkIn)
                    {
                        attendance.workingDay++;
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
                List<Attendance> attendances = attendanceRecords[employee.EmployeeID()];

                bool hasrecord = false;

                for (int i = 0; i < attendances.Count; i++)
                {
                    if (attendances[i].date.Date == today)
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

                    attendanceRecords[employee.EmployeeID()].Add(attendance);
                }
            }
        }

        //update khi người dùng checkin và checkout
        //kiểm tra mã nhân viên khi người dùng nhập vào 
        public void UpdateRecord(string employeeID)
        {
            List<Attendance> attendances = attendanceRecords[employeeID];
            DateTime today = DateTime.Today;
            DateTime now = DateTime.Now;
            foreach (Attendance attendance in attendances)
            {
                if (attendance.date == today)
                {
                    Console.WriteLine("Chon hanh dong tiep theo");
                    Console.WriteLine("1. Checkin");
                    Console.WriteLine("2. Checkout");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                attendance.checkInTime = now.TimeOfDay;
                                attendance.TimeIn(attendance.checkInTime);
                                attendance.checkIn = true;

                            }
                            break;
                        case 2:
                            {
                                attendance.checkOutTime = now.TimeOfDay;
                                attendance.TimeOut(attendance.checkOutTime);
                                attendance.checkOut = true;
                            }
                            break;
                    }
                }
            }
        }
    }
}
