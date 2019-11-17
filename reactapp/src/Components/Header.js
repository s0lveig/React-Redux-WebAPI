import React, {useState} from 'react';
import { Link } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import AddChair from './AddChair';
import AddTable from './AddTable';

const Header = () => {

    const [show, setShow] = useState(false);
    const openModal = () => setShow(true);
    const closeModal = () => setShow(false);

    const displayModal = () => {
        let url = window.location.href;
        if(url === "http://localhost:3000/chairs"){
            return <AddChair closeModal={closeModal} show={show} />
        } else if(url === "http://localhost:3000/tables") {
            return <AddTable closeModal={closeModal} show={show} />
        }
    }

    return(
        <header id="header-container" className="container-fluid">
            <div className="row">
                <div className="col-sm-4 mt-3">
                    <nav>
                        <Link to="/" className="text-reset p-1">Home</Link>
                        <Link to="/chairs" className="text-reset p-1">Chairs</Link>
                        <Link to="/tables" className="text-reset p-1">Tables</Link>
                    </nav>
                </div>
                <div className="col-sm-3 ml-auto mt-2 mb-2">
                    <input className="form-control form-control-sm" type="text" placeholder="Search" />
                </div>
                <Button className="col-sm-3 col-lg-2 ml-3 mr-3 mt-2 mb-2" variant="outline-dark" size="sm" onClick={openModal}>Add product +</Button>
            </div>
            {displayModal()}
        </header>
    )
}

export default Header;