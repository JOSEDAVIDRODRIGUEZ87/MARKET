// src/components/ProductForm.js
import { useForm } from 'react-hook-form';

const ProductForm = () => {
    const { register, handleSubmit, formState: { errors } } = useForm();

    const onSubmit = (data) => api.post('/products', data);

    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <input {...register("productName", { required: "Nombre obligatorio" })} />
            {errors.productName && <p>{errors.productName.message}</p>}
            <button type="submit">Guardar</button>
        </form>
    );
};