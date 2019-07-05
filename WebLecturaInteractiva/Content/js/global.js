((c,d,w) => {
    function SepararSilabas(word){
        let palabra = ""
        let silabas = []
        let control = true
        const vocales = ['A','E','I','O','U']
        const consonantes = ['B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'Ñ', 'P','Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z']
        const asentos = ['N','S']
        palabra = word
        let i = 0
        let limit = 2
        let tmpStr = ""
        let boolTieneVocal = false
        while(control){
            //c(" letras : " + limit + " index: " + i)
            //separo las 2 primeras letras si son silabas; si no 3
            for(i;i<limit;i++){
                tmpStr += palabra[i]
            }
            //c(tmpStr)
            for(let ind = 0;ind < tmpStr.length; ind++ ){
                //c(tmpStr[ind])
                if (vocales.includes(tmpStr[ind])) {
                    boolTieneVocal = true
                    //continue;
                }
            }//si no tiene vocal en las dos primeras letras entonces el limite tiene que ser 3
            if(boolTieneVocal){
                //c("tiene vocal letras: " + limit)
                if(vocales.includes(tmpStr[0])){ //si la primera letra es vocal entonces es la primera silaba
                    silabas.push(tmpStr[0])
                }else{
                    //c("Asentos: " + palabra[limit])
                    if(asentos.includes( palabra[limit])){//si las letras lleva un asento al final entonces se concatena ese asento al final
                        if(vocales.includes(palabra[limit+1])){//si las letras llevan un asento al final pero despues tienen una vocal; entonces no tiene asento
                            silabas.push(tmpStr)
                        }else{
                            silabas.push(tmpStr + palabra[limit])
                        }
                    }else{
                        if(vocales.includes(palabra[limit])  ){//si las letras llevan una vocal depues de una vocal 
                            if(asentos.includes(palabra[limit+1])){//si las letras llevan un asento despues de dos vocales
                                silabas.push(tmpStr + palabra[limit] + palabra[limit+1]) 
                            }else{
                                silabas.push(tmpStr + palabra[limit+1])
                            }
                        }else{
                            silabas.push(tmpStr)
                        }
                    }
                }
                i = silabas.join('').length
                limit = i + 2
                if(i>= palabra.length)
                    control = false
                tmpStr = ""
                //c("termino indice :" + i)
            }else{
                if (silabas.length === 0) {
                    limit = 3
                    i = 0
                }else{
                    limit = 3
                }
                tmpStr = ""
                //c("no tiene vocal letras : " + limit)
            }
        }
        c("palabra: ")
        c(palabra)
        c("Las silabas: ")
        c(silabas)
        return silabas
    }
    const easeOutBounce = (_, t, b, c, d) => {
        if ((t /= d) < 1 / 2.75) {
            return c * (7.5625 * t * t) + b;
        } else if (t < 2 / 2.75) {
            return c * (7.5625 * (t -= 1.5 / 2.75) * t + 0.75) + b;
        } else if (t < 2.5 / 2.75) {
            return c * (7.5625 * (t -= 2.25 / 2.75) * t + 0.9375) + b;
        } 
        return c * (7.5625 * (t -= 2.625 / 2.75) * t + 0.984375) + b;
    };
    function EliminateActive(elements) {
        Object.values(elements.childNodes).forEach(element => {
            //c(ev)
            if(element.className){
                let clases = element.className.split(' ')
                let strActive = "active"
                let resulClases = clases.includes(strActive) //element.find(m=>m === "active")
                if (resulClases) {
                    let indice = clases.findIndex(m=>m === strActive)
                    clases[indice] = ""
                    let newClass = Object.values(clases).join('')
                    c(newClass)
                    element.className = newClass
                }
            }
        })

    }
    //Esta funcion sirve para activar el elemento en que esta ubicado el scroll
    function ElementScroll (elementPadre,navElement){
        c(elementPadre)
        c(navElement)
        w.addEventListener("scroll",function(ev){
            let x = w.scrollX
            let y = w.scrollY
            let resul; 
            Object.values(elementPadre.childNodes).forEach(ev => { 
                let evY = Number.parseInt( ev.offsetTop - (ev.scrollHeight/2))
                let evX = ev.offsetLeft
                let maxY = Number.parseInt( ev.offsetTop + ev.scrollHeight)
                let maxX = Number.parseInt( ev.offsetLeft + ev.scrollWidth)
                if( y >= evY & y <= maxY ){
                    EliminateActive(elementPadre)
                    EliminateActive(navElement)
                    //c(ev.id)
                    let VarA = ev.id//El valor de esta variable se captura con respecto al scroll
                    let selecElement = navElement.querySelector('[href="#'+ VarA +'"]').parentElement
                    let selectElementParent = elementPadre.querySelector('[id = "' +VarA+'" ]')
                    //c("Elecmento Seleccionado :")
                    //c(selecElement)
                    selecElement.className = "active"
                    selectElementParent.className += " active"
                    selectElementParent.className.co
                }
            })
        })
    }

    $(d).ready(function(){
        $('[data-toggle="tooltip"]').tooltip()
        if (d.getElementsByClassName("divide-word")) {
            let elements = d.getElementsByClassName("divide-word")
            let valuesElements = []
            let word = "";
            const limitWord = 7
            let silabas = []
            let tmpStr = ""
            let newpalabra = []
            Object.values(elements).forEach(function(m){ 
                //c(m)
                Object.values(m.children).forEach(s=>{
                    Object.values(s.children).forEach(d=>valuesElements.push(d.innerText))
                    //c(valuesElements.join(""))
                    word = valuesElements.join("")
                    if(word.length > limitWord){
                        silabas = SepararSilabas(word)
                        let control = true;
                        let i = 0
                        let limit = silabas.length
                        while(control){
                            for(i;i<limit;i++){
                                tmpStr += silabas[i]   
                            }
                            //c(tmpStr)
                            if(tmpStr.length <= limitWord){
                                control = false
                            }else{
                                limit--
                                i = 0
                                tmpStr = ""
                            }
                        }
                        //c("limite:" + limit)
                        control = true
                        i = 0
                        while(control){
                            //c("indice : " + i + "limit : " + limit)
                            for(i; i<limit; i++){
                            //    c(silabas[i])
                                let tmpSilabas = silabas[i].split('')
                                //c(tmpSilabas)
                                for(let val of tmpSilabas){
                                    //c(val)
                                    let tmpSpan = d.createElement("span")
                                    tmpSpan.appendChild(d.createTextNode(val))
                                    newpalabra.push(tmpSpan)
                                }
                                //c(newpalabra)
                            }   
                            if(limit < silabas.length){
                                tmpSpan = d.createElement("span")
                                tmpSpan.appendChild(d.createTextNode("-"))
                                newpalabra.push(tmpSpan)
                                newpalabra.push(d.createElement("br"))
                                limit = silabas.length
                            }else if(limit >= silabas.length){
                                control = false
                            }
                        }
                        s.innerHTML = ""
                        for(let val of newpalabra){
                            s.appendChild(val)
                        }
                    }
                })

            })
        }
        /*if(d.querySelector('[data-spys="scroll"]')){
            //let scrollElement = d.querySelector('[data-spys="scroll"]');
            //let valOffset = parseInt( (scrollElement.scrollHeight * 3.00500050) / 100);
            //c(valOffset)
            //var scroller = new SweetScroll({ offset:valOffset});
            //let navId = scrollElement.dataset.target;
            //c("ID del div para marcar la lista : " + navId)
            //let navElement = d.getElementById(navId)
            //c("Elemento del id : " )
            //c(scrollElement)
            //funcion para marcar el nav con e
            //ElementScroll(scrollElement,navElement)
        }  */
    })

})(console.log,document,window)