import React, {useState} from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import axios from 'axios';

const Chair = (props) => {
    const [ state, setState ] = useState('');

    const [show, setShow] = useState(false);

    const hideModal = () => setShow(false);
    const openModal = () => setShow(true);

    const handleChange = ( event ) => {
        let input = event.target.value;
        setState({ 
            ...state,
            [event.target.name]: input
        });
    }

    const delChair = ( ) => {
        setShow(false);
        let id = props.id
        axios.delete("https://localhost:5001/chairs/" + id);
    }

    const editChair = ( event ) => {
        event.preventDefault();

        let updateChair = { 
            id: props.id,
            title: state.title, 
            year: Number.parseInt(state.year, 10),
            producer: state.producer,
            designer: state.designer,
            category: state.category,
            description: state.description,
            condition: state.condition,
            price: Number.parseInt(state.price, 10),
            image: props.image
        }
        
            for(var key in updateChair) {
                
                if(updateChair[key] === undefined) {
                    updateChair[key] = props[key];
                } 
                if(Object.is(updateChair[key], NaN)) {
                    updateChair[key] = Number.parseInt(props[key], 10)
                }
            }

        axios.put("https://localhost:5001/chairs", updateChair);
        alert("Chair updated!")
    }

    return(
        <>
        <div className="col-sm-6 col-md-4 col-lg-3 mb-2">
            <div className="card">
                <h4>{props.title}</h4>
                <p>{props.designer}</p>
                <p>{props.producer}</p>
                <p>{props.year}</p>
                <p>{props.category}</p>
                <p>{props.description}</p>
                <p>{props.condition}</p>
                <p>{props.price}</p>
                <img src={ 'http://localhost:5000/images/' + props.image} />
                <Button variant="secondary" size="sm" onClick={openModal}>Edit</Button>
            </div>
        </div>
        <Modal show={show} onHide={hideModal} animation={false}>
            <Modal.Header closeButton>
                <Modal.Title>Edit Product</Modal.Title>  
            </Modal.Header>
            <Modal.Body>
            <Form onSubmit={editChair}>
                <Form.Control onChange={handleChange} name="title" type="text" placeholder={props.title} className="mb-2" />
                <Form.Control onChange={handleChange} name="designer" type="text" placeholder={props.designer} className="mb-2" />
                <Form.Control onChange={handleChange} name="producer" type="text" placeholder={props.producer} className="mb-2" />
                <Form.Control onChange={handleChange} name="year" type="text" placeholder={props.year} className="mb-2" />
                <Form.Control onChange={handleChange} name="category" type="text" placeholder={props.category} className="mb-2" />
                <Form.Control onChange={handleChange} name="description" type="text" placeholder={props.description} className="mb-2" />
                <Form.Control onChange={handleChange} name="condition" type="text" placeholder={props.condition.toString()} className="mb-2" />
                <Form.Control onChange={handleChange} name="price" type="text" placeholder={props.price} className="mb-2" />
            
                <Button variant="secondary" type="submit">Update</Button>
            </Form>
            </Modal.Body>
            <Modal.Footer>                
                <Button variant="warning" onClick={delChair}>Delete</Button>
                <Button variant="outline-secondary" onClick={hideModal}>Close</Button>
            </Modal.Footer>
        </Modal>    
        </>
    )
}

export default Chair;