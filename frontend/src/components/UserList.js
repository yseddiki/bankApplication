import React,{Component,useState,useEffect} from "react";
import axios from 'axios';
import Navbar from "./NavBar";
    function UserList(){
    const [state,setState] = useState([])
    useEffect(()=> {
        axios.get('https://localhost:7082/api/HelbUser/list')
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
            <h2 class="titleh2">  List of Users </h2>

            <div class="myDiv">
                <table>
                    <tr>
                        <th>id</th>
                        <th>username</th>
                        <th>firstName</th>
                        <th>lastName</th>
                        <th>address</th>
                        <th>city</th>
                        <th>postalCode</th>
                        <th>email</th>
                    </tr>
                    {
                        state.length ?
                            state.map(user =>
                            <tbody key={user.id}>
                                <td>{user.username}</td>
                                <td>{user.password}</td>
                                <td>{user.firstName}</td>
                                <td>{user.lastName}</td>
                                <td>{user.address}</td>
                                <td>{user.city}</td>
                                <td>{user.postalCode}</td>
                                <td>{user.email}</td>
                            </tbody>
                            ):
                            null
                    }
                </table>
            </div>
        </div>
    )
}
export default UserList
