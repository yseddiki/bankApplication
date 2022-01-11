import React, {useState} from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Routes,
  Link,
  useRouteMatch,
  useParams
} from "react-router-dom";
import LoginForm from './components/LoginForm';
import UserList from './components/UserList';
import BankTransfersList from "./components/BankTransfersList";
import Navbar from "./components/NavBar";
import AccountList from "./components/AccountList";

function App() {

  return (
      <Router>
        <Routes>
          <Route path="/" element={<LoginForm />} />
          <Route path="/bankTransfer" element={<BankTransfersList />} />
          <Route path="/user" element={<UserList />} />
          <Route path="/account" element={<AccountList />} />
        </Routes>
      </Router>
  );
}
export default App;
