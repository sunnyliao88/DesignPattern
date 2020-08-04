using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    class SingeltonDPLoading
    {
        public static void Demo()
        {
              LazyLoadingDemo();
           // EagerLoadingDemo();
        }
        static void LazyLoadingDemo()
        {
            //var c1 = LazyLoadingClass.Instance;
            //var c2 = LazyLoadingClass.Instance;      

            Parallel.Invoke(
                () => GetInstance(), 
                () => GetInstance()
                );
            void GetInstance()
            {
                var i = LazyLoadingClass.Instance;
            }
        }

        static void EagerLoadingDemo()
        {
            //var c1 = EagerLoadingClass.Instance;
            //var c2 = EagerLoadingClass.Instance;

            Parallel.Invoke(() => GetInstance(), () => GetInstance());
            void GetInstance()
            {
                var i = EagerLoadingClass.Instance;
            }
        }
    }

    sealed class LazyLoadingClass
    {
        static object _lock = new object();
        static int count = 0;
        static Lazy<LazyLoadingClass> _instance;
        public static LazyLoadingClass Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Lazy<LazyLoadingClass>(() => new LazyLoadingClass());
                        }
                    }
                }
                return _instance.Value;
            }
        }
        private LazyLoadingClass()
        {
            count++;
            Console.WriteLine($"Count is: {count}");
        }
    }
    sealed class EagerLoadingClass
    {
        static int count = 0;
        static int static_count = 0;
        static readonly EagerLoadingClass _instance = new EagerLoadingClass();
        public static EagerLoadingClass Instance
        {
            get
            {
                return _instance;
            }
        }
        private EagerLoadingClass()
        {
            count++;
            Console.WriteLine($"Privater constructor.  Count is: {count}");
        }
        static EagerLoadingClass()
        {
            static_count++;
            Console.WriteLine($"Static constructor.  Count is: {static_count}");
        }

    }
}
