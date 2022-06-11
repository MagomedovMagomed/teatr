using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ApplicationData
{
	class AppContent
	{
		public static Entities1 Model1;
        private static Entities1 _context;
        public static Entities1 GetContext()
        {
            if (_context == null)
            {
                _context = new Entities1();
            }
            return _context;
        }
    }
}
