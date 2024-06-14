using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DubbeleKingen;

namespace DubbeleKingen
{
    public class NavigationManager
    {
        #region PROPERTIES
        // Depth 0 is the main page, negatives are not allowed
        private int _depth = 0;
        private SortedDictionary<int, string> _items;
        #endregion

        public NavigationManager()
        {
            _items = new();
            ItemsInit();
        }
        private void ItemsInit()
        {
            _depth = 0;
            _items.Add(_depth, nameof(MainPage));
        }


        public async Task GoToMain()
        {
            try
            {
                _items.Clear();
                ItemsInit();
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}", false);
            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("error", ex.Message, "ok"); }
        }

        public async Task GoBackXPages(int x)
        {
            if (x > _depth)
                return;
            try
            {
                var list = new List<int>();
                
                foreach (var k in _items.Keys)
                {
                    if (k > (_depth - x))
                        list.Add(k);
                }
                list.ForEach(k => _items.Remove(k));
                _depth -= x;
                await Relocate();
            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("error", ex.Message, "ok"); }

        }
        public async Task GoBackXPages(int x, IDictionary<string, object> data)
        {
            if (x > _depth)
                return;
            try { 
            foreach (var k in _items.Keys)
            {
                if (k > (_depth - x))
                    _items.Remove(k);
            }
            _depth -= x;
            await Relocate(data);
            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("error", ex.Message, "ok"); }

        }

        public async Task GoFurtherOnePage(string name)
        {
            if (name == string.Empty)
                return;
            try
            {
                _depth++;
                _items.Add(_depth, name);
                
                await Relocate();
            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("error", ex.Message, "ok"); }
                
        }
        public async Task GoFurtherOnePage(string name, IDictionary<string, object> data)
        {
            if (name == string.Empty)
                return;
            try {
                _depth++;
                _items.Add(_depth, name);
                await this.Relocate(data);
            }
            catch(Exception ex)
            { await Shell.Current.DisplayAlert("error", ex.Message, "ok"); }
        }

        public async Task GoToSameDepthPage(string name)
        {
            if (name == string.Empty)
                return;
            try
            {
                _items.Remove(_depth);
                _items.Add(_depth, name);
                await this.Relocate();
            }
            catch (Exception ex)
            { await Shell.Current.DisplayAlert("error", ex.Message, "ok"); }
        }
        public async Task GoToSameDepthPage(string name, IDictionary<string, object> data)
        {
            if (name == string.Empty)
                return;
            try
            {
                _items.Remove(_depth);
                _items.Add(_depth, name);
                await this.Relocate(data);
            }
            catch (Exception ex)
            { await Shell.Current.DisplayAlert("error", ex.Message, "ok"); }
        }


        private async Task Relocate()
        {
            await Shell.Current.GoToAsync(_items.Last().Value, false);
        }
        private async Task Relocate(IDictionary<string,object> data)
        {
            await Shell.Current.GoToAsync(_items.Last().Value, false,data);
        }
    }
}
