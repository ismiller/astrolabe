using System;
using System.Collections.Generic;
using System.Linq;
using Astrolabe.Navigating.Abstraction;
using Astrolabe.Routing.Abstraction;

namespace Astrolabe.Navigating
{
    public class NavigationStack<TElement> : INavigationStack<TElement>
    {
        #region Private Fields

        private readonly Stack<TElement> _stack;

        private TElement _selectedElement;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Создает экземпляр <see cref="NavigationStack{TElement}"/>.
        /// </summary>
        public NavigationStack()
        {
            _stack = new Stack<TElement>();
            _selectedElement = default;
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
            _selectedElement = default;
        }

        /// <inheritdoc />
        public void Push(TElement element)
        {
            if (_selectedElement is not null)
            {
                _stack.Push(_selectedElement);
            }

            _selectedElement = element;
        }

        /// <inheritdoc />
        public void Reset()
        {
            while (_stack.Any())
            {
                _selectedElement = _stack.Pop();
            }
        }

        /// <inheritdoc />
        public bool TryPop(out TElement element)
        {
            if (!Any())
            {
                element = _selectedElement;
                return false;
            }

            _selectedElement = _stack.Pop();
            element = _selectedElement;
            return true;
        }

        #endregion Public Methods
    }
}