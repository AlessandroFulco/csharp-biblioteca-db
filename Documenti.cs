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





public class Documento
{
    public string Codice { get; set; }
    public string Titolo { get; set; }
    public string Anno { get; set; }
    public bool Stato { get; set; }
    public int Scaffale { get; set; }
    public string Autore { get; set; }
    public string Settori { get; set; }

    public Documento(string codice, string titolo, string anno, bool stato, int scaffale, string autore, string settori)
    {
        Codice = codice;
        Titolo = titolo;
        Anno = anno;
        Stato = stato;
        Autore = autore;

        Scaffale = scaffale;

        Settori = settori;
    }

    public override string ToString()
    {
        return Codice + ", " + Titolo + ", " + Anno + ", " + Stato + ", " + "Scaffale: " + Scaffale + ", " + Autore + ", " + "Settore: " +Settori;
    }

}
