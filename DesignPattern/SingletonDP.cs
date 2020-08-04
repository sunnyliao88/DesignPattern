using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    class SingletonDP
    {
        public static void Demo()
        {          
           // SingleThreadDemo();        
            MultiThreadDemo();
        }
        static void SingleThreadDemo()
        {
            ThreadUnsafe singleton1 = ThreadUnsafe.Instance;
            singleton1.Name = "sunny";
            singleton1.Age = 20;
            ThreadUnsafe singleton2 = ThreadUnsafe.Instance;
            Console.WriteLine($"Name:{singleton1.Name}, Age: {singleton2.Age}");
            Console.WriteLine($"Only one instance: {singleton1 == singleton2}");

            ThreadSafe_1 threadSafe_1 = ThreadSafe_1.Instance;
            threadSafe_1.Name = "sunny";
            threadSafe_1.Age = 20;
            ThreadSafe_1 threadSafe_2 = ThreadSafe_1.Instance;
            Console.WriteLine($"Name:{threadSafe_1.Name}, Age: {threadSafe_2.Age}");
            Console.WriteLine($"Only one instance: {threadSafe_1 == threadSafe_2}");
        }
        static void MultiThreadDemo()
        {
            Task<ThreadSafe_1> task1 = new Task<ThreadSafe_1>(Thread1);
            Task<ThreadSafe_1> task2 = new Task<ThreadSafe_1>(Thread2);
            task1.Start();
            task2.Start();     
            Console.WriteLine($"Only one instance: {task1.Result == task2.Result}");
            Console.WriteLine($"---------------");
            Parallel.Invoke(() => Thread3(), () => Thread4());

            ThreadSafe_1 Thread1()
            {
                ThreadSafe_1 singleton = ThreadSafe_1.Instance;
                singleton.Name = "t1";
                singleton.Age = 20;
                Console.WriteLine($"-- Name:{singleton.Name}, Age: {singleton.Age}");
                return singleton;
            }

            ThreadSafe_1 Thread2()
            {
                ThreadSafe_1 singleton = ThreadSafe_1.Instance;
                singleton.Name = "t2";
                Console.WriteLine($"-- Name:{singleton.Name}, Age: {singleton.Age}");
                return singleton;
            }

            void Thread3()
            {
                ThreadSafe_2 singleton = ThreadSafe_2.Instance;
                singleton.Name = "t3";
                singleton.Age = 20;
                Console.WriteLine($"-- Name:{singleton.Name}, Age: {singleton.Age}");
            }

            void Thread4()
            {
                ThreadSafe_2 singleton = ThreadSafe_2.Instance;
                singleton.Name = "t4";
                Console.WriteLine($"-- Name:{singleton.Name}, Age: {singleton.Age}");
            }

        }
    }

    sealed class ThreadSafe_1
    {
        private static int counter = 0;
        public string Name { get; set; }
        public int Age { get; set; }
        static ThreadSafe_1 _instance;
        static object o = new object();
        static public ThreadSafe_1 Instance
        {
            get
            {
                lock (o)
                {
                    if (_instance == null)
                    {
                        _instance = new ThreadSafe_1();
                    }
                }
                return _instance;
            }
        }
        private ThreadSafe_1()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
    }

    sealed class ThreadSafe_2
    {
        private static int counter = 0;
        public string Name { get; set; }
        public int Age { get; set; }
        static readonly ThreadSafe_2 _instance=new ThreadSafe_2();      
        static public ThreadSafe_2 Instance
        {
            get
            {                
                return _instance;
            }
        }
        private ThreadSafe_2()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
    }

    sealed class ThreadUnsafe
    {
        private static int counter = 0;
        public string Name { get; set; }
        public int Age { get; set; }
        static ThreadUnsafe _instance;
        static public ThreadUnsafe Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ThreadUnsafe();
                }
                return _instance;
            }
        }
        private ThreadUnsafe()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }


    }


}
