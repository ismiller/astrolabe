using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AstrolabeExample.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <inheritdoc />
        protected virtual void OnPropertyChanged(object sender, [CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        /// Проверяет, действительно ли было измененно свойство.
        /// позволяет предотвратить создание бесконечного цикла обновления свойств.
        /// </summary>
        /// <typeparam name="TFiled">Тип свойства</typeparam>
        /// <param name="field">Свойство</param>
        /// <param name="value">Значение для свойства</param>
        /// <param name="property">Имя свойства</param>
        /// <returns><see langword="true"/> если значение было измененно, иначе <see langword="false"/></returns>
        protected virtual bool Set<TFiled>(ref TFiled field, TFiled value, [CallerMemberName] string property = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(this, property);
            return true;
        }
    }
}