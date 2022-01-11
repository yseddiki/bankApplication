import React,{Component,useEffect,useState} from "react";
import axios from 'axios';
import Timer from "../hooks/Timer";
import Navbar from "./NavBar";
import {BrowserRouter as Router} from "react-router-dom";

function BankTransfersList(){


    const [iban,setIban] = useState({codeIban:"" , name : ""});
    const [minute,setMinutes] = useState(5);

    const [state,setState] = useState([])
    const [isTimerVisible,setIsTimerVisible] = useState(false)
        useEffect(async ()=> {
     await  axios.get('https://localhost:7082/api/HelbBankTransfers/list')
           .then(response => {
               console.log(response)
               setState(response.data)
           })
           .catch(error =>{
               console.log(error)
           })
   },[])
    const  reset = async ()=> {
        await axios.get('https://localhost:7082/api/HelbBankTransfers/list')
            .then(response => {
                console.log(response)
                setState(response.data)
            })
            .catch(error =>{
                console.log(error)
            })
    }

    const handlefilter =async  ()=> {
        await axios.get('https://localhost:7082/api/HelbBankTransfers/IbanList/'+iban.codeIban)
            .then(response => {
                console.log(response)
                setState(response.data)
            })
            .catch(error =>{
                console.log(error)
            })
        await axios.get('https://localhost:7082/api/HelbBankTransfers/nameList/'+iban.name)
            .then(response => {
                console.log(response)
                setState(old => [...response.data,...old])
            })
            .catch(error =>{
                console.log(error)
            })

    }
    return(
        <div>
            <Navbar/>
            <h2 className="titleh2">List of Banktransfers</h2>
                Search by Iban : <input type="text" name="iban" id="codeIban" onChange={e => setIban({...iban, codeIban: e.target.value})} value={iban.codeIban}/>
                <br/>
                Search by Name : <input type="text" name="name" id="name" onChange={e => setIban({...iban, name: e.target.value})} value={iban.name}/>
                <br/>
            <button onClick={handlefilter}>Apply the filter</button>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <button onClick={reset}>Reset</button>
            {isTimerVisible && <Timer initialMinute={minute} reset={reset}/>}
            <div >
                <input type="text" name="name" id="name" onChange={e => setMinutes(parseInt(e.target.value))} value={minute}/>
                <button onClick={()=>{
                    setIsTimerVisible(true)
                    console.log(minute)
                }}>Set Minutes</button>
            </div>
            
            <div class="myDiv">
                <table>
                    <tr>
                        <th>receiverAccount</th>
                        <th>receiverAccount iban</th>
                        <th>expiditorAccount username</th>
                        <th>expiditorAccount iban</th>
                        <th>amount</th>
                        <th>communication</th>
                        <th>date</th>
                    </tr>
                    {
                        state.length ?
                            state.map(bk =>
                                <tbody key={bk.id}>
                                <td>{bk.receiverAccount.user.username}</td>
                                <td>{bk.receiverAccount.iban}</td>
                                <td>{bk.expeditorAccount.user.username}</td>
                                <td>{bk.expeditorAccount.iban}</td>
                                <td>{bk.amount}</td>
                                <td>{bk.communication}</td>
                                <td>{bk.dateExpedition}</td>
                                </tbody>
                            ) :(null)
                    }
                </table>
            </div>
        </div>
    )
}

export default BankTransfersList


