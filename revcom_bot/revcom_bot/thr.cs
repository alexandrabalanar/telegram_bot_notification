using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace revcom_bot
{
    class thr
    {

        static void check()
        {
            QWe qwe = new QWe();
            qwe.c();
        }

        public void Init()
        {
            Thread checkthread = new Thread(check);
            checkthread.Start();
        }

    }
}
