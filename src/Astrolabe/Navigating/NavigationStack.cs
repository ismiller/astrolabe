using System.Collections.Generic;
using System.Linq;
using Astrolabe.Navigating.Abstraction;

namespace Astrolabe.Navigating
{
    /// <summary>
    /// Предоставляет функционал стека навигации.
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    internal sealed class NavigationStack<TElement> : INavigationStack<TElement>
    {
        #region Private Fields

        private readonly Stack<TElement> _stack;
        private TElement _suspendElement;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Создает экземпляр <see cref="NavigationStack{TElement}"/>.
        /// </summary>
        public NavigationStack()
        {
            _stack = new Stack<TElement>();
            _suspendElement = default;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritdoc />
        public bool Any()
        {
            return _stack.Any();
        }

        /// <inheritdoc />
        public void Clear()
        {
            _stack.Clear();
            _suspendElement = default;
        }

        /// <inheritdoc />
        public bool TryGetSuspend(out TElement element)
        {
            element = default;
            if (_suspendElement is not null)
            {
                element = _suspendElement;
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public void Push(TElement element)
        {
            if (_suspendElement is not null)
            {
                _stack.Push(_suspendElement);
            }

            _suspendElement = element;
        }

        /// <inheritdoc />
        public void Reset()
        {
            while (_stack.Any())
            {
                _suspendElement = _stack.Pop();
            }
        }

        /// <inheritdoc />
        public bool TryPop(out TElement element)
        {
            if (Any() == false)
            {
                element = _suspendElement;
                return false;
            }

            _suspendElement = _stack.Pop();
            element = _suspendElement;
            return true;
        }

        #endregion Public Methods
    }
}