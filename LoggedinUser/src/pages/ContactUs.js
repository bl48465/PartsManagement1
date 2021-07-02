import '../components/Stilizimi/ContactUs.css';
import React, { useState } from "react";


const ContactUs = () => {
  const [name, setName] = useState("");
  const [company, setCompany] = useState("");
  const [phone, setPhone] = useState("");
  const [email, setEmail] = useState("");
  const [message, setMessage] = useState("");

  const isEmail = () =>{
    let mail = document.getElementById('not-mail');
    let regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    if(email.match(regex)){
      mail.style.display = 'none';
      return true;
    } else {
      mail.style.display = 'block';
      mail.style.animation = 'dongle 1s';
      setTimeout(()=>{
        mail.style.animation = 'none';
      },1000);
      return false;
    }
  }

  const failMessage = (message) => {
    let formMess = document.querySelector('.form-message');
    formMess.innerHTML = message;
    formMess.style.opacity = '1';
    formMess.style.background = 'rgb(253,87,87)';

    document.getElementById('name').classList.add('error');
    document.getElementById('email').classList.add('error');
    document.getElementById('message').classList.add('error');
  }
  const successMessage = () =>{
    let formMess = document.querySelector('.form-message');
    formMess.innerHTML = 'Message sent ! We will recontact you as soon as possible.';
    formMess.style.background = '#00c1ec';
    formMess.style.opacity = '1';

    document.getElementById('name').classList.remove('error');
    document.getElementById('email').classList.remove('error');
    document.getElementById('message').classList.remove('error');

    setTimeout(()=> {
      formMess.style.opactiy = '0';
    },5000);
  }

  const handleSubmit = (e) => {
    e.preventDefault();
    if(name && isEmail() && message ){
    sendFeedback("template_t2pxebc", {
      name,
      company,
      phone,
      email,
      message,
    });
    } else{
      failMessage("Please fill in the required fields correctly *");
    }
  };
  
  const sendFeedback = (templateId, variables) => {

    window.emailjs
    .send("gmail", templateId, variables)
      .then((res) => {
        successMessage();
        setName("");
        setCompany("");
        setPhone("");
        setEmail("");
        setMessage("");
      })
      .catch(
        (err) => {
          failMessage("An error has occurred. Please try again.")
        }
       )};

  return (
    <form className="contact-form">
      <h2>Contact us</h2>
      <div className="form-content">
        <input
          type="text"
          id="name"
          name="name"
          onChange={(e) => setName(e.target.value)}
          placeholder="Name *"
          value={name}
          autoComplete="off"
        />
        <input
          type="text"
          id="company"
          name="company"
          onChange={(e) => setCompany(e.target.value)}
          placeholder="Company"
          value={company}
        />
        <input
          type="text"
          id="phone"
          name="phone"
          onChange={(e) => setPhone(e.target.value)}
          placeholder="Phone"
          value={phone}
        />
        <div className="email-content">
          <label id="not-mail">Invalid email</label>
          <input
            type="mail"
            id="email"
            name="email"
            onChange={(e) => setEmail(e.target.value)}
            placeholder="Email *"
            value={email}
            autoComplete="off"
          />
        </div>
        <textarea
          id="message"
          name="message"
          onChange={(e) => setMessage(e.target.value)}
          placeholder="Message *"
          value={message}
        />
      </div>
      <input
        className="button"
        type="button"
        value="Send"
        onClick={handleSubmit}
      />
      <div className="form-message"></div>
    </form>
  );
};

export default ContactUs;
