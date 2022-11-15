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

public class Prestito
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Inizio { get; set; }
    public string Fine { get; set; }
    public Documento Documento { get; set; }

    public Prestito(string nome, string cognome, string inizio, string fine, Documento item)
    {
        Nome = nome;
        Cognome = cognome;
        Inizio = inizio;
        Fine = fine;
        Documento = item;
        Documento.Stato = true;
    }

    public override string ToString()
    {
        return"Nome: " + Nome + "Cognome: " + Cognome + " Durata prestito: " + Inizio + " - " + Fine + " documento: " + Documento.Titolo;
    }
}