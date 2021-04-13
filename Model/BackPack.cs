using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssignmentASCLib.Model
{
    //Wrapper/Adapter/Decorator
    public class BackPack
    {
        private List<Iitem> _content;
        private int _max;
        public BackPack(int max, params Iitem[] content)
        {
            _content = new List<Iitem>();
            _max = max;
            for (int i = 0; i < content.Length; i++)
                _content.Add(content[i]);
        }
        public List<String> ListItems()
        {
            List<String> strs = new List<string>();
            if (_content.Count > 0)
            {
                foreach (var item in _content)
                {
                    strs.Add(item.ToString());
                }
            }
            else
            {
                strs.Add("Backpack is empty");
            }
            return strs;
        }
        public bool AddItem(Iitem item)
        {
            if (PackIsFull())
            {
                return false;
            }
            else
            {
                _content.Add(item);
                return true;
            }
        }
        /// <summary>
        /// Removes it from back pack if item exists.
        /// Parameter and item name are lower-case to avoid bad user input.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>(true, item) if it exists; (false, null) if not</returns>
        public (bool, Iitem) TakeItem(String name)
        {
            try
            {
                var item = (true, (Iitem)_content.Where(i => i.Name.ToLower().Equals(name.ToLower())));
                _content.Remove((Iitem)_content.Where(i => i.Name.ToLower().Equals(name.ToLower())));
                return item;
            }
            catch
            {
                return (false, null);
            }
        }
        public bool PackIsFull()
        {
            return _content.Count <= _max;
        }

    }
}
