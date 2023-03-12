
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Behaviours
{
    public class ComportamientosValidaciones<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ComportamientosValidaciones(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var recibeValidacion = new FluentValidation.ValidationContext<TRequest>(request);
                var ValidacionResultado = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(recibeValidacion, cancellationToken)));
                var Errores = ValidacionResultado.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (Errores.Count != 0)
                {
                    throw new Exceptions.ExcepcionesValidacion();
                }
            }
            return await next();
        }
      
    }
    }

