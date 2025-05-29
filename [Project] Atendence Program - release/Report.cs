using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace _Project__Atendence_Program
{
    public class Report
    {
        public class Report
        {
            public int ReportID { get; private set; }
            public string Content { get; private set; }
            public DateTime Date { get; private set; }
            public int ValidAbsentDays { get; private set; }
            public int InvalidAbsentDays { get; private set; }
            public int OvertimeDays { get; private set; }
            public int LateTimes { get; private set; }
            public int AttendanceDays { get; private set; }

            // Thêm List để lưu trữ tất cả các báo cáo
            public static List<Report> AllReports { get; set; } = new List<Report>();

            public Report()
            {
                ValidAbsentDays = 12;
                InvalidAbsentDays = 0;
                OvertimeDays = 0;
                LateTimes = 0;
                AttendanceDays = 0;
                Date = DateTime.Now;

                AllReports.Add(this);
            }

            public void ValidAbsent(List<Attendance> attendances) // nghỉ có phép
            {
                foreach (Attendance attendance in attendances)
                {
                    if (attendance.employeeID == EmployeeID && attendance.CheckIn)
                    {
                        ValidAbsentDays--;
                    }
                }
            }
            public void AddInvalidAbsentDays(List<Attendance> attendances) // nghỉ ko phép
            {
                if (ValidAbsentDays == 0)
                {
                    foreach (Attendance attendance in attendances)
                    {
                        if (attendance.employeeID == EmployeeID && attendance.CheckIn)
                        {
                            InvalidAbsentDays++;
                        }
                    }
                }
            }
            public void AddOvertimeDays(List<Attendance> attendances) // tăng ca
            {
                foreach (Attendance attendance in attendances)
                {
                    if (attendance.employeeID == EmployeeID && !attendance.CheckOut && attendance.OtTime.TotalHours > 0)
                    {
                        OvertimeDays++;
                    }
                }
            }
            public void AddLateTimes(List<Attendance> attendances) // đi trễ
            {
                foreach (Attendance attendance in attendances)
                {
                    if (attendance.employeeID == EmployeeID && !attendance.CheckIn && attendance.Status == "late")
                    {
                        LateTimes++;
                    }
                }
            }
            public void CalculateAttendanceDay(List<Attendance> attendances) // tính tổng ngày đi làm 
            {
                foreach (Attendance attendance in attendances)
                {
                    if (attendance.employeeID == EmployeeID && !attendance.CheckIn && !attendance.CheckOut)
                    {
                        AttendanceDays++;
                    }
                }
            }
            public void DisplayReport()
            {
                Console.WriteLine($"Report ID: {ReportID}");
                Console.WriteLine($"Employee ID: {EmployeeID}");
                Console.WriteLine($"Date: {Date.ToShortDateString()}");
                Console.WriteLine($"Valid Absent Days Remain: {ValidAbsentDays}");
                Console.WriteLine($"Invalid Absent Days: {InvalidAbsentDays}");
                Console.WriteLine($"Overtime Days: {OvertimeDays}");
                Console.WriteLine($"Late Times: {LateTimes}");
                Console.WriteLine($"Attendance Days: {AttendanceDays}");
                Console.WriteLine("----------------------------");
            }

        }
    }
}
