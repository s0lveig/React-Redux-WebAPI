import React, {useState} from 'react';
import { Link } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import AddChair from './AddChair';

const Header = () => {

    const [show, setShow] = useState(false);

    const openModal = () => setShow(true);
    const closeModal = () => setShow(false);

    return(
        <header id="header-container" className="container-fluid">
            <div className="row mt-3 mb-3">
                <div className="col-6">
                    <nav>
                        <Link to="/" className="text-reset p-1">Home</Link>
                        <Link to="/chairs" className="text-reset p-1">Chairs</Link>
                    </nav>
                </div>
                <div className="col-6 text-right">
                    <Button variant="outline-dark" size="sm" onClick={openModal}>Add product +</Button>
                </div>
            </div>

            <AddChair closeModal={closeModal} show={show} />
        </header>
    )
}

export default Header;