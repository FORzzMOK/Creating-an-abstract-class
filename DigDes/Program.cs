using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DigDes
{
    
    public abstract class PrintDigDes
    {
        public PrintDigDes() { }
        public void Print()
        {
            Console.WriteLine("DigDes");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Type TypePrintDigDes = typeof(PrintDigDes);
            ConstructorInfo magicConstructor = TypePrintDigDes.GetConstructor(Type.EmptyTypes);//get Constructor

            Type TypeRuntimeMethodHandle = typeof(RuntimeMethodHandle);
            MethodInfo magicMethod = TypeRuntimeMethodHandle.GetMethod("InvokeMethod", BindingFlags.Static | BindingFlags.NonPublic);//get InvokeMethod from RunTimeMethodHandle

            PropertyInfo sigInfo = magicConstructor.GetType().GetProperty("Signature", BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);//get signature
            PrintDigDes abstrObj = (PrintDigDes)magicMethod.Invoke(null, new object[] { null, null, sigInfo.GetValue(magicConstructor), true , null});

            abstrObj.Print();

            Console.ReadLine();
        }
    }
}
