namespace Project_KTMH
{
    partial class AttendanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblWorkingDays;
        private System.Windows.Forms.ListBox lstAttendanceHistory;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtStatus;
    }
}