/*Richiesta:
    Si vuole progettare un sistema per la gestione di una biblioteca dove il bibliotecario può verificare i dati dei clienti registrati

    cognome,
    nome,
    email,
    recapito telefonico,

    Il bibliotecario può effettuare dei prestiti ai suoi clienti registrati, attraverso il sistema, sui documenti che sono di vario tipo (libri, DVD). I documenti sono caratterizzati da:

    un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
    titolo,
    anno,
    settore (storia, matematica, economia, …),
    stato (In Prestito, Disponibile),
    uno scaffale in cui è posizionato,
    un autore (Nome, Cognome).
    Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.

    Il bibliotecario deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, effettuare dei prestiti registrando il periodo (Dal/Al) del prestito e il documento.
    Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un cliente.
    Mi raccomando, prima di buttarvi sul codice fate qualche schema per capire le entità principali e le loro relazioni / eredità.
    Buon lavoro! (modificato) 
*/


//Biblioteca biblioteca = new Biblioteca();



//bool continua = true;
//while (continua)
//{
//    //Benvenuto 
//    Console.WriteLine("Benvenuto");
//    Console.WriteLine("Scrivi una delle opzionis: ");
//    //funzioni possibili: crea prestito, cerca un libro o un dvd
//    Console.WriteLine("     1. Cerca un libro");
//    Console.WriteLine("     2. Cerca un dvd");
//    Console.WriteLine("     3. Crea un prestito per un libro");
//    Console.WriteLine("     4. Crea un prestito per un Dvd");
//    Console.WriteLine("     5. Lista prestiti");
//    Console.WriteLine("     6. Esci");

//    string inputUtente = Console.ReadLine().ToLower();

//    switch (inputUtente)
//    {
//        case "cerca un libro":
//            Console.WriteLine("Quale libro vuoi cercare?");
//            string libro = Console.ReadLine().ToLower();
//            Console.WriteLine(biblioteca.CercaLibro(libro).ToString());
//            libro = null;
//            break;

//        case "cerca un dvd":
//            Console.WriteLine("Quale dvd vuoi cercare?");
//            string dvd = Console.ReadLine().ToLower();
//            Console.WriteLine(biblioteca.CercaDvd(dvd).ToString());
//            break;

//        case "crea un prestito per un libro":
//            //chiede il nome utente
//            Console.WriteLine("inserisci nome utente registrato");
//            string libroInputNomeUtente = Console.ReadLine(); 
//            //chiede il cognome utente
//            Console.WriteLine("inserisci cognome utente registrato");
//            string libroInputCognomeUtente = Console.ReadLine(); 
//            //chiede il libro per creare il prestito
//            Console.WriteLine("Quale libro vuoi prendere in prestito?");
//            string inputLibro = Console.ReadLine().ToLower();
//            bool prestitoLibro = biblioteca.CreaPrestitoLibro(libroInputNomeUtente, libroInputCognomeUtente, inputLibro);
//            if (prestitoLibro)
//                Console.WriteLine("Prestito avvenuto con successo");
//            else
//                Console.WriteLine("il libro è gia stato preso in prestito");
//            break;

//        case "crea un prestito per un Dvd":
//            //chiede il nome utente
//            Console.WriteLine("inserisci nome utente registrato");
//            string dvdInputNomeUtente = Console.ReadLine();
//            //chiede il cognome utente
//            Console.WriteLine("inserisci cognome utente registrato");
//            string dvdInputCognomeUtente = Console.ReadLine();
//            //chiedere il dvd per creare il prestito
//            Console.WriteLine("Quale Dvd vuoi prendere in prestito?");
//            string inputDvd = Console.ReadLine().ToLower();
//            bool prestitoDvd = biblioteca.CreaPrestitoDvd(dvdInputNomeUtente, dvdInputCognomeUtente, inputDvd);
//            if (prestitoDvd)
//                Console.WriteLine("Prestito avvenuto con successo");
//            else
//                Console.WriteLine("il Dvd è gia stato preso in prestito");
//            break;

//        case "lista prestiti":
//            Console.WriteLine("Ecco la lista dei prestiti attivi");
//            biblioteca.StampaPrestiti();
//            break;

//        case "esci":
//            continua = false;
//            break;

//        default:
//            Console.WriteLine("opzione non disponibile");
//            break;
//    }
//}


using System.Data.SqlClient;

string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";


SqlConnection connessione = new SqlConnection(stringaDiConnessione);

connessione.Open();

Database.AggiungiDocumento("3412", "prova", new DateTime(2022, 05, 06), "2A", true, "matematica", "alessandro", connessione);

Database.AggiungiPrestito("alessandro", "Fulco", new DateTime(2022, 11, 11), new DateTime(2023, 11, 11), "libro", 1, connessione);

connessione.Close();