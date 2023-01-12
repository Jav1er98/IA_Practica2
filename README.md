## Práctica 2: Modificación del proyecto Linea de Vision.
## Objetivo: Modificar el proyecto Línea de Visión para que use una máquina de estado finito.

Añadimos un Nav Mesh al mapa, dos obstaculos sacados del proyecto FMS, los pondremos como Nav Mesh Obstacle y luego seleccionamos los obstaculos y el suelo plano del mapa para hacer el Bake, para controlar al robot le añadimos tambien un componente Nav Mesh Agent.

Creamos la máquina de estados, con un animation controller Añadiendo los diferentes estados como se nos solicita, el metodo hide utilizado es el CleverHide en este caso. En el script World, tenemos una lista de los objetos donde el robot puede esconderse (buscando los objetos con la etiqueta "hide"). En el OnStateUpdate() de Hide recorremos toda la lista de objetos donde puede esconderse el robot, calculamos la dirección respecto al jugador de cada lugar de escondite y una distancia para el escondite. De todos los escondites, buscamos el que tenga la distancia menor y la elegimos como el escondite donde el robot va a esconderse. Mientras se encuentre en Hide, el robot recuperará su vida, cuando su vida se recupera al máximo vuelve al estado Patrol.

1.  Los estados son: Patrol: implementa el método "wander". Si el jugador entra en el campo de visión del agente pasa el estado "Chase":

      ![gif ejercicio 1](/gifs/gif1.gif)
      
2. Chase: implementa "Seek" o "Pursue" para seguir al jugador. Si el jugador está dentro de la distancia de tiro pasa al estado "Attack". Si el jugador deja de estar en el campo de visión, pasa al estado "Patrol"

      ![gif ejercicio 2](/gifs/gif2.gif)
   
3. Attack: dispara al jugador. Si la distancia con el jugador es superior a la distancia de tiro, pasa al estado "Chase". Si la vida del NPC está por debajo de una cantidad, pasa al estado "Hide".
       
      ![gif ejercicio 3](/gifs/gif3.gif)
       
4. Hide: implementa el método "Hide" o "CleverHide" y regenera la vida del NPC. Si la vida está por encima de un valor, pasa al estado "Patrol":

      ![gif ejercicio 4](/gifs/gif4.gif)
      ![gif ejercicio 4](/gifs/gif5.gif)
