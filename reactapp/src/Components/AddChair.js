import React, { useState } from "react";
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import axios from 'axios';

const AddChair = (props) => {
  const { show, closeModal } = props;
  const [ state, setState ] = useState({
    title: "Title",
    year: 1900,
    producer: "Producer",
    designer: "Designer",
    category: "Category",
    description: "Description",
    condition: true,
    price: 0,
    image: "Imagetitle"
  });

    const handleChange = ( event ) => {
        let input = event.target.value;
        setState({ 
            ...state,
            [event.target.name]: input
        });
    }

  const addNewChair = ( event ) => {
        event.preventDefault();
        let file = document.getElementById("upload-img");
        let data = new FormData();
        data.append("file", file.files[0]);

        function setImg() {
            let imgFile = "imgfile"
            if(file.files[0] === undefined){
                imgFile = "lcm.jpg"
            } else { 
                axios({
                    method: 'post',
                    url: 'https://localhost:5001/Chairs/uploadImg',
                    data: data,
                    config: { headers: {'Content-Type': 'multipart/form-data' }}
                })
                imgFile = file.files[0].name 
            }
            return imgFile
        }
    
        let newChair = { 
            title: state.title, 
            year: Number.parseInt(state.year, 10),
            producer: state.producer,
            designer: state.designer,
            category: state.category,
            description: state.description,
            condition: state.condition,
            price: Number.parseInt(state.price, 10),
            image: setImg()
        };

        axios.post("https://localhost:5001/chairs", newChair);
        alert("New chair added!")
    }

  return (
    <>
      <Modal show={show} onHide={closeModal} animation={false}>
        <Modal.Header closeButton>
                    <Modal.Title>Add Product</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form onSubmit={ addNewChair }>
                            <Form.Control onChange={handleChange} name="title" type="text" value={state.title} className="mb-2" />
                            <Form.Control onChange={handleChange} name="designer" type="text" value={state.designer} className="mb-2" />
                            <Form.Control onChange={handleChange} name="producer" type="text" value={state.producer} className="mb-2" />

                            <Form.Row className="mb-2">
                                <Col>
                                <Form.Label>Category</Form.Label>
                                </Col>
                                <Col>
                                <Form.Control as="select">
                                    <option>Lounge Chair</option>
                                    <option>Dining Chair</option>
                                    <option>Office Chair</option>
                                </Form.Control>
                                </Col>
                            </Form.Row>
                            <Form.Row>
                                <Col>
                                <Form.Control onChange={handleChange} name="year" placeholder="Year" type="number" />
                                </Col>
                                <Col>
                                <Form.Control onChange={handleChange} name="price" placeholder="Price" type="number" />
                                </Col>
                            </Form.Row>
                            {['checkbox'].map(check => (
                                <div key={`inline-${check}`} className="m-3">
                                    <Form.Check inline label="New" check={check} id={`inline-${check}-1`} />
                                    <Form.Check inline label="Vintage" check={check} id={`inline-${check}-1`} />
                                </div>
                            ))}

                        <Form.Control as="textarea" rows="3" onChange={handleChange} name="description" value={state.description} className="mb-2" />
                        <input onChange={handleChange} id="upload-img" type="file" name="image" />

                        <Button variant="secondary" type="submit">Add +</Button>
                        </Form>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="outline-secondary" onClick={closeModal}>Close</Button>
                    </Modal.Footer>
      </Modal>
    </>
  );
}

export default AddChair;