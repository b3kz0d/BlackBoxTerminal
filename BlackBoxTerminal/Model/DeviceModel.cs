using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace BlackBoxTerminal.Model
{
    public class DeviceModel
    {
        public string Name { get; set; }
        public RuleCollection RuleCollection { get; set; }
        public bool IsMaster { get; set; }

        public DeviceModel()
        {
            RuleCollection=new RuleCollection();
        }
    }

    public class DeviceCollection : ObservableCollection<DeviceModel>
    {
        
    }

    public class RuleModel
    {
        public Guid Id { get; set; }
        public byte[] Match { get; set; }
        public string MatchColor { get; set; }
        public int Interval { get; set; }
        public byte[] OutMessage { get; set; }
        public string OutMessageColor { get; set; }
        public bool Enabled { get; set; }
        public RuleModel()
        {
            Id = Guid.NewGuid();
        }

        
    }

    public class RuleCollection : ObservableCollection<RuleModel>
    {
        public RuleModel CheckMatchRule(byte[] match)
        {
            for (int index = 0; index < Count; index++)
            {
                var r = this[index];
                if(!r.Enabled) continue;
                if (r.Match.SequenceEqual(match))
                {
                    return r;
                }
            }
            return null;
        }

        public RuleModel CheckOutMessageRule(byte[] outMessage)
        {
            for (int index = 0; index < Count; index++)
            {
                var r = this[index];
                if (!r.Enabled) continue;
                if (r.OutMessage.SequenceEqual(outMessage))
                {
                    return r;
                }
            }
            return null;
        }

        public void Delete(Guid id)
        {
            var rule = this.FirstOrDefault(x => x.Id == id);
            if (rule != null)
                Remove(rule);
        }
    }
}
