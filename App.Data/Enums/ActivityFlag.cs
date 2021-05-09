using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Enums
{
    public enum ActivityFlag
    {
        UnusualBehaviour = 0,
        UnusualCashDeposit,
        UnusualRecurringCashDeposit,
        UnusualWithdrawalAmount,
        UnusualDepositAmount,
        KYCMissing,
        MissingInformation
    }
}
