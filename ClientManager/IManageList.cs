using System.ComponentModel;

namespace ClientManager
{
    public interface IManageList<T>
    {
        void SaveList(BindingList<T> serverList);

        BindingList<T> ReadList();
    }
}
