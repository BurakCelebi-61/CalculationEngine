using System;
using System.Collections.Generic;
using System.Data;

namespace CalculationEngine
{
    public class Condition
    {
        public string Formule { get; set; }
        public string Proviso { get; set; }
        public bool Result { get; set; }
        private bool _result = false;
        public void Run()
        {
            string ef = Formule.Replace("&&", "&").Replace("||", "|");
            foreach (string r in ef.Split('&'))
            {
                foreach (string r2 in r.Split('&'))
                {

                }
            }
        }
        //IIF([Status] = 'Yes', 'Go', 'Stop' )
        //private static bool Cond(string Condition)
        //{
        //string _cond = Condition
        //.Replace("!=", "ED")
        //.Replace("==", "EE")
        //.Replace(">=", "BE")
        //.Replace(">", "BB")
        //.Replace("<=", "KE")
        //.Replace("<", "KK");
        //}
    }
    public class Calculation
    {
        string _Formule { get; set; }
        List<Variable> _variables { get; set; }
        public Calculation(in List<Variable> variables,in List<Condition> _conditions)
        {
            //if (formule != null)
            //{
            //    Formule = formule;
            //}
            //else
            //{
            //    Formule = string.Empty;
            //}
            if (variables != null)
            {
                Variables = variables;
            }
            else
            {
                Variables = new List<Variable>();
            }
            if (_conditions !=null)
            {
                Conditions = _conditions;
            }
            else
            {
                Conditions = new List<Condition>();
            }
        }
        public List<Condition> Conditions { get; set; }
        public string Formule 
        {
            get { return _Formule; }
            set 
            {
                _Formule = value;
                Result = 0;
            }
        }
        public List<Variable> Variables {
            get { return _variables; } 
            set
            {
                _variables = value;
                Result = 0;
            }
        }
        public decimal Result { get; set; }
        #region Compute
        public decimal Compute()
        {
            string s2 = string.Empty;
            foreach (Condition con in Conditions)
            {
                if ((new DataTable().Compute($"IIF( {con.Proviso}, 'True', 'False' )", "").ToString()).ToBool())
                {
                    s2 = con.Formule;
                }
            }
            //string s2 = Formule;
            foreach (Variable v in Variables)
            {
                s2 = s2.Replace(v.Name, v.Value.ToString());
            }
            try
            {
                Result = (new DataTable().Compute(s2, "").ToString()).ToDecimal();
            }
            catch (Exception)
            {
                throw;
            }

            return Result;
        }
        public List<decimal> MultiCompute()
        {
            string s2 = string.Empty;
            List<decimal> Result = new List<decimal>();
            foreach (Condition con in Conditions)
            {
                if ((new DataTable().Compute($"IIF( {con.Proviso}, 'True', 'False' )", "").ToString()).ToBool())
                {
                    s2 = con.Formule;
                    foreach (Variable v in Variables)
                    {
                        s2 = s2.Replace(v.Name, v.Value.ToString());
                    }
                    try
                    {
                        Result.Add((new DataTable().Compute(s2, "").ToString()).ToDecimal());
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            //string s2 = Formule;
            

            return Result;
        }

        public int ComputeInt()
        {
            string s2 = string.Empty;
            int Result = 0;
            foreach (Condition con in Conditions)
            {
                if ((new DataTable().Compute($"IIF( {con.Proviso}, 'True', 'False' )", "").ToString()).ToBool())
                {
                    s2 = con.Formule;
                }
            }
            //string s2 = Formule;
            foreach (Variable v in Variables)
            {
                s2 = s2.Replace(v.Name, v.Value.ToString());
            }
            try
            {
                Result = (new DataTable().Compute(s2, "").ToString()).ToInt();
            }
            catch (Exception)
            {
                throw;
            }

            return Result;
        }
        public List<int> MultiComputeInt()
        {
            string s2 = string.Empty;
            List<int> Result = new List<int>();
            foreach (Condition con in Conditions)
            {
                if ((new DataTable().Compute($"IIF( {con.Proviso}, 'True', 'False' )", "").ToString()).ToBool())
                {
                    s2 = con.Formule;
                    foreach (Variable v in Variables)
                    {
                        s2 = s2.Replace(v.Name, v.Value.ToString());
                    }
                    try
                    {
                        Result.Add((new DataTable().Compute(s2, "").ToString()).ToInt());
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            //string s2 = Formule;


            return Result;
        }
        ///// <summary>
        ///// Eski Version
        ///// </summary>
        ///// <returns></returns>
        //public int ComputeInt()
        //{
        //    string s2 = Formule;
        //    foreach (Variable v in Variables)
        //    {
        //        s2 = s2.Replace(v.Name, v.Value.ToString());
        //    }
        //    try
        //    {
        //        return (new DataTable().Compute(s2, string.Empty).ToString()).ToInt();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        #endregion
        public void SetVariable(string name, decimal value)
        {
            try
            {
                foreach (Variable v in Variables)
                {
                    if (v.Name == name)
                    {
                        v.Value = value;
                        return;
                    }
                }
                Variables.Add(new Variable(name, value));
            }
            catch (Exception ex)
            {
                throw new Exception("CLC01 : Değer Yükleme Hatası.", ex);
            }
            finally
            {

            }
            
        }
        public void RemoveVarible(string name)
        {
            Variable rv = null;
            foreach (Variable variable in Variables)
            {
                if (variable.Name == name)
                {
                    rv = variable;
                }
            }
            if (rv != null)
            {
                Variables.Remove(rv);
                Result = 0;
            }
        }
        public void CleanVariable()
        {
            Variables = new List<Variable>();
        }
        public void CleanCondition()
        {
            Conditions = new List<Condition>();
        }
    }
}
