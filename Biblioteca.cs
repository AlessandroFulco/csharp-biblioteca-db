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

public class Biblioteca
{
    

    //Lista libri
    public List<Libro> libroList = new List<Libro>();
    //Lista Dvd
    public List<Dvd> dvdList = new List<Dvd>();
    //lista prestiti
    public List<Prestito> prestiti = new List<Prestito>();
    public List<Utente> utenteList = new List<Utente>();

    public Biblioteca()
    {
        //creazioni libri
        Libro libro1 = new Libro(200, "12345678", "topolino", "10-05-2006", false, 1, "Alessandro Fulco", "Statistica");
        Libro libro2 = new Libro(200, "18295432", "Guerra e pace", "10-05-2006", false, 3, "Alessandro Fulco", "Statistica");
        Libro libro3 = new Libro(200, "93572746", "La Conoscienza di Zeno", "10-05-2006", false, 5, "Alessandro Fulco", "Statistica");
        //aggiunta alla Lista Libri
        libroList.Add(libro1); //aggiunta libro alla lista
        libroList.Add(libro2); //aggiunta libro alla lista
        libroList.Add(libro3); //aggiunta libro alla lista

        //creazione Dvd
        Dvd dvd1 = new Dvd(3, "31647523", "A sangue freddo", "14-03-2011", false, 2, "Alessandro Fulco", "Matematica");
        Dvd dvd2 = new Dvd(3, "62357524", "Grandi speranze", "14-03-2011", false, 4, "Alessandro Fulco", "Matematica");
        Dvd dvd3 = new Dvd(3, "72624262", "Pinocchio", "14-03-2011", false, 6, "Alessandro Fulco", "Matematica");
        //aggiunta alla lista Dvd
        dvdList.Add(dvd1); //aggiunta dvd alla lista
        dvdList.Add(dvd2); //aggiunta dvd alla lista
        dvdList.Add(dvd3); //aggiunta dvd alla lista

        //creazione utenti
        Utente ut1 = new Utente("Fulco", "Alessandro", "alessandro@prova.it", "1235124431", true);
        Utente ut2 = new Utente("Rossi", "Mario", "mario@prova.it", "1235124431", false);
        //aggiunta utenti alla lista
        utenteList.Add(ut1);
        utenteList.Add(ut2);
    }

    //ricerca libro
    public Libro CercaLibro(string input)
    {
        //variabile per la funzione di ricerca dei documenti
        Libro Risultato = null;

        foreach (Libro libro in libroList)
        {
            if (libro.Titolo.ToLower() == input || libro.Codice == input)
            {
                Risultato = libro;
                break;
            }
        }
        return Risultato;
    }
    //ricerca dvd
    public Dvd CercaDvd(string input)
    {
        //variabile per la funzione di ricerca dei documenti
        Dvd Risultato = null;

        foreach (Dvd dvd in dvdList)
        {
            if (dvd.Titolo.ToLower() == input || dvd.Codice == input)
            {
                Risultato = dvd;
                break;
            }
        }
        return Risultato;
    }


    //crea ed aggiunge il prestito alla lista
    public bool CreaPrestitoLibro(string nome, string cognome, string libro)
    {
        Libro libroTrovato = null;

            foreach (Libro documento in libroList)
            {
                if (documento.Codice.ToLower() == libro && documento.Stato == false || documento.Titolo.ToLower() == libro && documento.Stato == false)
                {
                    documento.Stato = true;
                    libroTrovato = documento;
                    //creazione prestito
                    Prestito prestitoLibro1 = new Prestito(nome, cognome, "10-10-2022", "15-10-2022", libroTrovato);
                    prestiti.Add(prestitoLibro1);
                    break;
                }
            }
        if (libroTrovato == null)
                
        {
            return false;
        }
        else if (libroTrovato.Stato == true)
                return true;
        else 
            return false;
    }
    public bool CreaPrestitoDvd(string nome, string cognome, string dvd)
    {
        Dvd dvdTrovato = null;

            foreach (Dvd documento in dvdList)
            {
                if (documento.Codice.ToLower() == dvd && documento.Stato == false || documento.Titolo.ToLower() == dvd && documento.Stato == false)
                {
                    documento.Stato = true;
                dvdTrovato = documento;
                    //creazione prestito
                    Prestito prestitoLibro1 = new Prestito(nome, cognome, "10-10-2022", "15-10-2022", dvdTrovato);
                    prestiti.Add(prestitoLibro1);
                    break;
                }
            }
        if (dvdTrovato == null)
                
        {
            return false;
        }
        else if (dvdTrovato.Stato == true)
                return true;
        else 
            return false;
    }

    //TODO
    //public bool RicercaPrestito(string nome, string cognome)
    //{



    //    return false;
    //}


    //stampa prestito
    public void StampaPrestiti()
    {
        Console.WriteLine("Prestiti: ");
        foreach(Prestito prestito in prestiti)
        {
            Console.WriteLine(prestito.ToString());
        }
    }
}
