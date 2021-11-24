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
        private int value = 0;
        public event ValueChange OnValueChange;
        public virtual void SetValue(int value)
        {
            if (Check(value))
            {
                this.value = value;

                if (OnValueChange != null) OnValueChange.Invoke(value);
            }
        }

        public int GetValue() => value;

        public bool Check(int value) => value >= 0 && value <= 100;


    }

    public class ModelA:Model
    {
        public override void SetValue(int value)
        {
            base.SetValue(value);
        }

        public void ModelCChange(int value)
        {
            if (this.GetValue() > value) this.SetValue(value);
        }
    }

    public class ModelB:Model
    {
        ModelA modelA;
        ModelC modelC;

        public ModelB(ModelA a, ModelC c)
        {
            this.modelA = a;
            this.modelC = c;
        }

        public override void SetValue(int value)
        {
            if (value < modelA.GetValue() || value > modelC.GetValue())
            {
                base.SetValue(this.GetValue());
                return;
            }
            base.SetValue(value);
        }

        public void ModelAChange(int value)
        {
            if (this.GetValue() < value) this.SetValue(value);
        }
        public void ModelCChange(int value)
        {
            if (this.GetValue() > value) this.SetValue(value);
        }
    }

    public class ModelC:Model
    {

        public override void SetValue(int value)
        {
            base.SetValue(value);
        }

        public void ModelAChange(int value)
        {
            if (this.GetValue() < value) this.SetValue(value);
        }
    }

}
