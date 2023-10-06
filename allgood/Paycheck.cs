using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allgood
{
    internal class Paycheck
    {
        public decimal GrossAmount { get; set; }
        public decimal Oasdi { get; set; }
        public decimal Medicare { get; set; }
        public decimal FedTax { get; set; }
        public decimal NcStateTax { get; set; }
        public decimal Add { get; set; }
        public decimal GroupTermLife { get; set; }
        public decimal LongTermDisability { get; set; }
        public decimal EeVoluntaryLife { get; set; }
        public decimal HdHpPremium { get; set; }
        public decimal HsaContribution { get; set; }
        public decimal EsppContribution { get; set; }
        public decimal Roth401kContribution { get; set; }

        public decimal NetAmount => GrossAmount - Oasdi - Medicare - FedTax -
            NcStateTax - Add - GroupTermLife - LongTermDisability - EeVoluntaryLife -
            HdHpPremium - HsaContribution - EsppContribution - Roth401kContribution;

        public static Paycheck Generate()
        {
            return new Paycheck()
            {
                GrossAmount = 6615.87m,
                Oasdi = 412.28m,
                Medicare = 96.42m,
                FedTax = 1206.12m,
                NcStateTax = 297m,
                Add = 4.20m,
                GroupTermLife = 7.87m,
                LongTermDisability = 16.27m,
                EeVoluntaryLife = 111.93m,
                EsppContribution = 661.59m,
                Roth401kContribution = 396.96m
            };
        }
    }
}
