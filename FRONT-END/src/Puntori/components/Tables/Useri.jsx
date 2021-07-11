import React, { useState } from 'react'
import { Card, Icon, Image, Button, Form,Transition } from 'semantic-ui-react'
import matthew from '../../images/matthew.png';
import styled from "styled-components";

export const BoxContainer = styled.div`
margin-left:30%;
width:40%;
margin-top:3%;
display:flex;
`;



export default function UserCard() {
    const [active, setActive] = useState(true);

    return (
        <BoxContainer>
            <Card>
                <Image src={matthew} wrapped ui={false} />
                <Card.Content>
                    <Card.Header>Matthew</Card.Header>
                    <Card.Meta>
                        <span className='date'>Joined in 2015</span>
                    </Card.Meta>
                    <Card.Description>
                        Matthew eshte nje shites i autopjeseve.
                    </Card.Description>
                </Card.Content>
                <Card.Content extra>

                    <Icon name='user' />
                    Uniteti
                    <Button icon className="butoniEditit" onClick={() => setActive(!active)} color='blue'>
                        <Icon name='edit' />
                    </Button>
                </Card.Content>

            </Card>
            <Transition visible={!active} animation='scale' duration={500}>
       
            <Form className={active ? "forma hide" : "forma unhide"}>
                <Form.Field>
                    <label>Emri:</label>
                    <input placeholder='Emri' />
                </Form.Field>
                <Form.Field>
                    <label>Email:</label>
                    <input placeholder='Email' />
                </Form.Field>
                <Form.Field>
                    <label>Kompania:</label>
                    <input placeholder='Kompania' />
                </Form.Field>
                <Form.Field>
                    <label>Password:</label>
                    <input type="password" placeholder='Password' />
                </Form.Field>
                <Button type='submit' color="blue">Ruaj</Button> <Button color="red" onClick={() => setActive(!active)} >Mbyll</Button>
            </Form>
            </Transition>
        </BoxContainer>
    );
}
