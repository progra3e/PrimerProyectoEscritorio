El Principio de responsabilidad única (Single Responsibility Principle)
Se aplico este principio al diseño de nuestras clases:
- Se quitó el código de guardar en Txt y en Json del programa principal.
- Se creo una clase PersonaPersistencia para poner todo el código relacionado con los archivos.
No se colocó el código de manejo de archivos dentro de la clase Persona que ya existe, porque
violaría el principio de Responsabilidad Única que dice que una clase solo debe tener una razón
por la cual hay que cambiarla.
La clase Persona solo debería de cambiar si tenemos que agregar algún dato extra, por ejemplo
el NIT de la persona, o la dirección de la Persona. Pero si ponemos ahí el manejo de archivos,
esa sería otra razón para que la clase cambiara, por ejemplo si ahora se necesita que se
guarde en una base de datos eso también haría que la clase cambie. Por eso todo lo de la
persistencia se paso a otra clase.
