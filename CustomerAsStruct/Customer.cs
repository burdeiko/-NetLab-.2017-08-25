using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAsStruct
{
    public struct Customer: IEquatable<Customer>, IComparable<Customer>
    {
        #region Constructor
        public Customer (int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion
        #region Properties
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        #endregion
        #region IComparable
        public int CompareTo(Customer other, Comparison<Customer> comparison)
        {
            return comparison(this, other);
        }

        public int CompareTo(Customer other)
        {
            return CompareTo(other, ByFullName);
        }
        #endregion
        #region Operators
        public static bool GreaterThan(Customer arg1, Customer arg2)
        {
            return arg1.CompareTo(arg2) > 0 ? true : false;
        }

        public static bool operator >(Customer arg1, Customer arg2)
        {
            return GreaterThan(arg1, arg2);
        }

        public static bool LessThan(Customer arg1, Customer arg2)
        {
            return arg1.CompareTo(arg2) < 0 ? true : false;
        }

        public static bool operator <(Customer arg1, Customer arg2)
        {
            return LessThan(arg1, arg2);
        }
        #endregion
        #region Comparisons
        public static readonly Comparison<Customer> ByFirstName = (arg1, arg2) =>
            arg1.FirstName.CompareTo(arg2.FirstName);

        public static readonly Comparison<Customer> ByLastName = (arg1, arg2) =>
            arg1.LastName.CompareTo(arg2.LastName);

        public static readonly Comparison<Customer> ByFullName = (arg1, arg2) =>
            (arg1.FirstName + arg1.LastName).CompareTo(arg2.FirstName + arg2.LastName);
        #endregion
        #region IEquatable
        public bool Equals(Customer other)
        {
            return Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return Equals(this, obj);
        }

        public static bool Equals(Customer arg1, Customer arg2)
        {
            return arg1.Id == arg2.Id;
        }
        public override string ToString()
        {
            return Id.ToString() + "," + FirstName + "," + LastName;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        #endregion
    }
}
