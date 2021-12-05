using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public delegate void ValueChange(int value);
    public class Model
    {
        private int valueA = 0;
        private int valueB = 0;
        private int valueC = 0;
        public event ValueChange OnValueChangeA;
        public event ValueChange OnValueChangeB;
        public event ValueChange OnValueChangeC;
        public void SetValueA(int value)
        {
            if (Check(value))
            {
                this.valueA = value;

                if (OnValueChangeA != null) OnValueChangeA.Invoke(value);
                ModelAChange();
            }
        }

        public void SetValueB(int value)
        {
            if (Check(value))
            {
                if (value < valueA || value > valueC)
                {
                    SetValueB(valueB);
                    return;
                }
                this.valueB = value;
                if (OnValueChangeB != null) OnValueChangeB.Invoke(value);
            }
        }

        public void SetValueC(int value)
        {
            if (Check(value))
            {
                this.valueC = value;

                if (OnValueChangeC != null) OnValueChangeC.Invoke(value);
                ModelCChange();
            }
        }

        public int GetValueA() => valueA;
        public int GetValueB() => valueB;
        public int GetValueC() => valueC;

        public bool Check(int value) => value >= 0 && value <= 100;

        public void ModelCChange()
        {
            if (valueA > valueC) this.SetValueA(valueC);
            if (valueB > valueC) this.SetValueB(valueC);
        }
        public void ModelAChange()
        {
            if (valueA > valueC) this.SetValueC(valueA);
            if (valueB < valueA) this.SetValueB(valueA);
        }


    }




}
