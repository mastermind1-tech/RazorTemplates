using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace RazorTemplates;

internal class FragmentComponent : ComponentBase
{
    [Parameter]
    public required RenderFragment RenderFragment { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.AddContent(0, RenderFragment);
    }

    public readonly struct ParametersDictionary(RenderFragment fragment)
        : IReadOnlyDictionary<string, object?>, IDictionary<string, object?>
    {
        private static readonly IEnumerable<string> _keys = [nameof(FragmentComponent.RenderFragment)];
        private readonly RenderFragment _fragment = fragment;

        public object? this[string key] => key == nameof(FragmentComponent.RenderFragment) ? _fragment : null;
        public IEnumerable<string> Keys => _keys;
        public IEnumerable<object?> Values => [_fragment];
        public int Count => 1;

        ICollection<string> IDictionary<string, object?>.Keys => [.. _keys];
        ICollection<object?> IDictionary<string, object?>.Values => [_fragment];
        public bool IsReadOnly => true;

        object? IDictionary<string, object?>.this[string key]
        {
            get => this[key];
            set => throw new NotImplementedException();
        }

        public bool ContainsKey(string key) => key == nameof(FragmentComponent.RenderFragment);
        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            yield return new KeyValuePair<string, object?>(nameof(FragmentComponent.RenderFragment), _fragment);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        public bool TryGetValue(string key, out object? value)
        {
            if (key == nameof(FragmentComponent.RenderFragment))
            {
                value = _fragment;
                return true;
            }
            value = null;
            return false;
        }

        public void Add(string key, object? value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<string, object?> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, object?> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, object?>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, object?> item)
        {
            throw new NotImplementedException();
        }
    }
}
