using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp.Model
{
    [Serializable]
    class Account
    {
        private string _name;
        private int _accNo;
        private int _accBal;

        public Account(string name, int accNo) : this("sid", 102, 1000)
        { }

        public Account(string name, int accNo, int accBal)
        {
            _name = name;
            _accNo = accNo;
            _accBal = accBal;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = "abc";
            }
        }

        public int AccNo
        {
            get
            {
                return _accNo;
            }
            set
            {
                if (value > 100)
                    _accNo = value;
            }
        }

        public int Balance
        {
            get
            {
                return _accBal;
            }
            set
            {
                if (value >= 1000)
                    _accBal = value;
            }
        }

        public void deposit(int deposit)
        {
            _accBal += deposit;
        }

        public int withdraw(int withdraw)
        {
            if (_accBal - withdraw < 1000)
                throw new Exception("Insufficient Balance!!!");
            else
            {
                _accBal = _accBal - withdraw;
                return _accBal;
            }
        }
    }
}
