using Bank;
using System;
using Xunit;

namespace BankXUnitTests
{
    public class BankAccountTests
    {
        [Fact]
        public void Adding_Funds_Updates_Balance()
        {
            // ar
            var account = new KontoBankowe(2000);

            // ac
            account.Add(100);

            // as
            Assert.Equal(2100, account.Balance);
        }

        [Fact]
        public void Adding_Negative_Funds_Throws()
        {
            // ar
            var account = new KontoBankowe(2000);

            // ac as
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-200));
        }

        [Fact]
        public void Withdrawing_Funds_Updates_Balance()
        {
            // ar
            var account = new KontoBankowe(2000);

            // ac
            account.Withdraw(200);

            // as
            Assert.Equal(1800, account.Balance);
        }

        [Fact]
        public void Withdrawing_Negative_Funds_Throws()
        {
            // ar
            var account = new KontoBankowe(1000);

            // ac as
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-100));
        }

        [Fact]
        public void Withdrawing_More_Than_Funds_Throws()
        {
            // ar
            var account = new KontoBankowe(1000);

            // ac as
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2000));
        }

        [Fact]
        public void Transfering_Funds_Updates_Both_Accounts()
        {
            // ar
            var account = new KontoBankowe(1000);
            var otherAccount = new KontoBankowe();

            // ac
            account.TransferFundsTo(otherAccount, 300);

            // as
            Assert.Equal(700, account.Balance);
            Assert.Equal(300, otherAccount.Balance);
        }

        [Fact]
        public void TransferFundsTo_Non_Existing_Account_Throws()
        {
            // ar
            var account = new KontoBankowe(1000);

            // ac as
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 2000));
        }
    }
}
