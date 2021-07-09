export default function validateInfo(values) {
    let errors = {};
  
    if (!values.emrimbiemri.trim()) {
      errors.emrimbiemri = 'Emri dhe mbiemri duhet te shenohen';
    }
    // else if (!/^[A-Za-z]+/.test(values.name.trim())) {
    //   errors.name = 'Enter a valid name';
    // }
  
    if (!values.email) {
      errors.email = 'Email eshte obligativ';
    } else if (!/\S+@\S+\.\S+/.test(values.email)) {
      errors.email = 'Email address is invalid';
    }
    if (!values.marka) {
      errors.marka = 'Marka eshte obligative';
    } 
    if (!values.modeli) {
        errors.modeli = 'Modeli eshte obligativ';
      } 
      
  
    
    return errors;
  }
  