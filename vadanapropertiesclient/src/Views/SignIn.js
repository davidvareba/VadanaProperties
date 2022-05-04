import React from 'react';
import PropTypes from 'prop-types';
import { signInUser } from '../Data/Auth';

export default function SignIn({ user }) {
    return (
        <>
                <div className="sign-in mt-5" align="center">
                    <p>
                        <button
                            type="button"
                            className="btn btn-success"
                            onClick={signInUser}
                        >
                            Sign In
                        </button>
                    </p>
                </div>
            
        </>
    );
}

SignIn.propTypes = {
    user: PropTypes.node,
};

SignIn.defaultProps = {
    user: null,
};
