using System;

namespace Bank
{

    //testowanie prostego kodu aplikacji konta bankowego//

    //konto bankowe//
    public class KontoBankowe
    {
        private double balance;

        public KontoBankowe()
        {
        }

        public KontoBankowe(double balance)
        {
            this.balance = balance;
        }

        //konto bankowe zwracanie//

        public double Balance
        {
            get { return balance; }
        }

        //dodawanie funduszy na konto bankowe//

        public void Add(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            balance += amount;
        }

        //możliwość wypłacania pieniędzy//

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            balance -= amount;
        }

        //przelewanie pieniędzy na inne konto bankowe//

        public void TransferFundsTo(KontoBankowe otherAccount, double amount)
        {
            if (otherAccount is null)
            {
                throw new ArgumentNullException(nameof(otherAccount));
            }

            Withdraw(amount);
            otherAccount.Add(amount);
        }
    }
}
