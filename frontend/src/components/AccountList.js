import React,{Component,useState,useEffect} from "react";
import axios from 'axios';
import Navbar from "./NavBar";
function AccountList(){
    const [state,setState] = useState([])
    useEffect(()=> {
        axios.get('https://localhost:7082/api/HelbAccount/list')
            .then(response => {
                console.log(response)
                setState(response.data)
            })
            .catch(error =>{
                console.log(error)
            })
    },[])
    return(
        <div>
            <Navbar/>
            <h2 class="titleh2">  List of accounts </h2>

            <div class="myDiv">
                <table>
                    <tr>
                        <th>IBAN</th>
                        <th>Account user</th>
                        <th>Balance</th>
                    </tr>
                    {
                        state.length ?
                            state.map(account =>
                                <tbody key={account.id}>
                                    <td>{account.iban}</td>
                                    <td>{account.user.username}</td>
                                    <td>{account.balance}</td>
                                </tbody>
                            ):
                            null
                    }
                </table>
            </div>
        </div>
    )
}
export default AccountList
