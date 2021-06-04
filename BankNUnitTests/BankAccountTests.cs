using Bank;
using System;
using NUnit.Framework;

namespace BankNUnitTests
{
    public class BankAccountTests
    {
        private KontoBankowe account;

        [SetUp]
        public void Setup()

        {
            // arr
            account = new KontoBankowe(2000);
        }

        //dodawanie funduszy aktualizuje balans konta//
        [Test]
        public void Adding_Funds_Updates_Balance()
        {
            // ac
            account.Add(200);

            // as
            Assert.AreEqual(2200, account.Balance);
        }

        [Test]
        public void Adding_Negative_Funds_Throws()
        {
            // as + as
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-200));
        }

        //wyp³acanie funduszy aktualizuje balans konta//
        [Test]
        public void Withdrawing_Funds_Updates_Balance()
        {
            // ac
            account.Withdraw(1000);

            // as
            Assert.AreEqual(1000, account.Balance);
        }

        //wyp³acanie//
        [Test]
        public void Withdrawing_Negative_Funds_Throws()
        {
            // a + a
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-500));
        }

        //wyp³acanie wiêcej ni¿ mamy//
        [Test]
        public void Withdrawing_More_Than_Balance_Throws()
        {
            // a + a
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2500));
        }

        //updateuj'emy oba konta//
        [Test]
        public void Transfering_Funds_Updates_Both_Accounts()
        {
            // arr
            var otherAccount = new KontoBankowe();

            // ac
            account.TransferFundsTo(otherAccount, 500);

            // ass
            Assert.AreEqual(1500, account.Balance);
            Assert.AreEqual(500, otherAccount.Balance);
        }

        //na nieistniej¹ce konto transfer//
        [Test]
        public void Transfer_To_Non_Existing_Account_Throws()
        {
            // as + ass
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 2000));
        }
    }
}