using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpression
{
    class Program
    {
        //lambda表达式一般遵循以下几个规则：
        //1.lambda包含的参数数量必须与委托类型包含的参数数量一致。
        //2.lambda中每个输入参数必须都能够隐式转换为其对应的委托参数(逆变性)
        //3.lambda的返回值(如果有返回值)必须能够隐式转换为委托的返回类型(协变性)
        public delegate string MyDlg(ClassOne father);
        public delegate ClassOne MyDlg2();
        static void Main(string[] args)
        {
            var str1 = CalcDlg(new ClassTwo(), o => o.Calc());
            Console.WriteLine(str1);

            var two = CalcDlg2(() => new ClassTwo());
            Console.WriteLine(two);
        }

        static string CalcDlg(ClassOne father, MyDlg @delegate) => @delegate(father);
        static ClassOne CalcDlg2(MyDlg2 @delegate)
        {
            return @delegate();
        }
    }
}


class ClassOne
{
    public virtual string Calc()
    {
        return "Father Calc";
    }
}
class ClassTwo : ClassOne
{
    public override string Calc()
    {
        return "Son Calc";
    }
}