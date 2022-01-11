import  React,{useState} from 'react';
import axios from "axios";
import {useNavigate} from "react-router-dom";


export default function LoginForm(){
    const [details,setDetails] = useState({username:"",password:""});
    const Navigate = useNavigate()
    const submitHandler = e => {
        e.preventDefault();
        axios.post("https://localhost:7082/api/HelbAuth/login",details).then((res)=> {
            Navigate("/bankTransfer",{token :res.data})
        }).catch(console.log)
    }

    return(
        <form onSubmit={submitHandler}>
            <div className="form-inner">
                <h2>Superviseur login</h2>
                <div className="form-group">
                    <label htmlFor="email">Username:</label>
                    <input type="text" name="username" id="username" onChange={e=> setDetails({...details,username :e.target.value})} value={details.username}/>
                </div>
                <div className="form-group">
                    <label htmlFor="name">Password:</label>
                    <input type="password" name="password" id="password" onChange={e=> setDetails({...details,password :e.target.value})} value={details.password}/>
                </div>
                <input type="submit" value="Login"/>
            </div>
        </form>
    )

}