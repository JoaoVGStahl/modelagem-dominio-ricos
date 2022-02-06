using PontoSysStore.Core.Messages;
using System;
using System.Collections.Generic;

namespace PontoSysStore.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        private List<Event> _notificacoes;

        public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public void AdicionarEvento(Event eventItem)
        {
            _notificacoes = _notificacoes ?? new List<Event>(); 
            _notificacoes?.Add(eventItem);
        }
        public void RemoverEvento(Event eventItem)
        {
            _notificacoes?.Remove(eventItem);
        }
        public void LimparEventos()
        {
            _notificacoes?.Clear();
        }

        public override bool Equals(object obj)
        {
            var compareTO = obj as Entity;

            if (ReferenceEquals(this, compareTO)) return true;
            if (ReferenceEquals(null, compareTO)) return false;

            return Id.Equals(compareTO.Id);
        }

        public static bool operator == (Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator != (Entity a, Entity b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 314) + Id.GetHashCode();
        }
        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
