# Istruzioni per l'uso
Clonare la repository in locale 

    git clone https://github.com/BazzoneRec/ProgettoTest.git
    
 Spostarsi all'interno della cartella contenente la repository clonata, aprire una shell ed eseguire il comando

    docker-compose up --build

Una volta terminata la build, sarà possibile [visualizzare l'applicazione](http://localhost:5000)

# Sviluppi

Al momento il click sul bottone per inviare la richiesta invia dei dati statici (quelli specificati nel .svg di esempio), i quali vengono poi salvati in un database mysql. I valori dei dati presenti nella richiesta vengono poi sommati. Questa somma, in prima battuta, viene ritornata in risposta e loggata in console.