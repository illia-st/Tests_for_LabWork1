using System;
using Xunit;
using Laboratory_work1;

namespace Laboratory_work1.Tests
{
    public class UnitTest1 : MyExcel
    {
        public UnitTest1() : base()
        {}
        [Fact]
        public void CalculatorTests()
        {
            Assert.Equal(Calculator.Evaluate("1+2"), 3);
            Assert.Equal(Calculator.Evaluate("2 * (2 + 3)"), 10);
            Assert.Equal(Calculator.Evaluate("2 + 2 * (2 + 3)"), 12);
            Assert.Equal(Calculator.Evaluate("1/2"), 0.5);
            Assert.Equal(Calculator.Evaluate("-1 -- 1"), 0);
            Assert.Equal(Calculator.Evaluate("4 ^ 0.5"), 2);
            Assert.Equal(Calculator.Evaluate("min(1,2)"), 1);
            Assert.Equal(Calculator.Evaluate("max(1,2)"), 2);
            Assert.Throws<DivideByZeroException>(() => Calculator.Evaluate("1/0"));
            Assert.Throws<FormatException>(() => Calculator.Evaluate("1 + (5 +) 2"));
            Assert.False(Parens(")("));
        }
        [Fact]
        public void Add_Del_Rows_Cols()
        {
            MyExcel data = new MyExcel();
            Assert.Equal(data.GetCols(), 10);
            Assert.Equal(data.GetRows(), 10);
            data.Add_Col();
            data.Add_Row();
            Assert.Equal(data.GetCols(), 11);
            Assert.Equal(data.GetRows(), 11);
            data.Add_Col();
            data.Add_Row();
            Assert.Equal(data.GetCols(), 12);
            Assert.Equal(data.GetRows(), 12);
            for (int i = 1; i <= 12; ++i)
            {
                if (i == 12)
                {
                    Assert.Equal(data.GetCols(), 1);
                    Assert.Equal(data.GetRows(), 1);
                    break;
                }
                data.Del_Col();
                data.Del_Row();
                Assert.Equal(data.GetCols(), 12 - i);
                Assert.Equal(data.GetRows(), 12 - i);
            }
        }

        [Fact]
        public void SetCellNameTests()
        {
            Assert.Equal(SetCellName(10, 10), "K11");
            Assert.Equal(SetCellName(99, 99), "CV100");
            Assert.Equal(SetCellName(55, 55), "BD56");
            Assert.Equal(SetCellName(86, 96), "CI97");
            Assert.Equal(SetCellName(56, 1), "BE2");
            Assert.Equal(SetCellName(0, 0), "A1");
            Assert.Equal(SetCellName(200, 0), "GS1");
        }
        
    }
}