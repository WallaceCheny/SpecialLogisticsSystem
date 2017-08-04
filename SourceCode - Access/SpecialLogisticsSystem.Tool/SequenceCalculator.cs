using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialLogisticsSystem.Tool
{
    public class SequenceCalculator<T>
    {
        private readonly IList<T> _oldSequence;
        private readonly IList<T> _newSequence;

        public SequenceCalculator(IList<T> oldSequence, IList<T> newSequence)
        {
            this._oldSequence = oldSequence;
            this._newSequence = newSequence;
        }

        public IList<T> OldSequence
        {
            get { return this._oldSequence; }
        }

        public IList<T> NewSequence
        {
            get { return this._newSequence; }
        }

        public IList<T> ToBeDeletedSequence
        {
            get
            {
                return _oldSequence.Except(_newSequence).ToList();
            }
        }

        public IList<T> ToBeInsertedSequence
        {
            get
            {
                return _newSequence.Except(_oldSequence).ToList();
            }
        }

        public IList<T> ToBeUpdatedSequence
        {
            get
            {
                return _oldSequence.Except(ToBeDeletedSequence).ToList();
            }
        }
    }
}
