namespace QuanLySuShi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static Dangnhap dangnhapForm = new Dangnhap();
        /// 
        [STAThread]
         static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(dangnhapForm);

            
        }

    }
}