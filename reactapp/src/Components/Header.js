import React, {useState} from 'react';
import Button from 'react-bootstrap/Button';
import AddChair from './AddChair';
import AddTable from './AddTable';
import { HashLink as Link } from 'react-router-hash-link';

/**
 * Header area, linking to components, as well as displaying the correct Add Product Modal
 * depending on which component is active.
 */
const Header = () => {

    let url = window.location.href;

    const [show, setShow] = useState(false);
    const openModal = () => setShow(true);
    const closeModal = () => setShow(false);

    const displayModal = () => {
        if(url === "http://localhost:3000/chairs"){
            return <AddChair closeModal={closeModal} show={show} />
        } else if(url === "http://localhost:3000/tables") {
            return <AddTable closeModal={closeModal} show={show} />
        }
    }

    const showModal = () => {
        if(url === "http://localhost:3000/"){
            alert("Go to a product category page to add a product to the store.")
        } else {
            openModal()
        }
    }

    return(
        <header id="header-container" className="container-fluid">
            <div className="row">
                <div className="col-sm-6 mt-2 mr-auto">
                    <nav>
                        <Link to="/" className="text-reset p-1">Home</Link>
                        <Link to="/chairs" className="text-reset p-1">Chairs</Link>
                        <Link to="/tables" className="text-reset p-1">Tables</Link>
                        <Link to="/#taskboard" className="text-reset p-1">Task-Board</Link>
                    </nav>
                </div>
                <Button className="col-md-2 col-sm-3 ml-3 mr-3 mt-2 mb-2" variant="outline-dark" size="sm" onClick={showModal}>Add product +</Button>
            </div>
            {displayModal()}
        </header>
    )
}

export default Header;