/**************************************************************************
 *                                                                        *
 *  File:        InvalidExtensionException.cs                             *
 *  Copyright:   (c) 2021, Rusu Iulian                                    *
 *  E-mail:      iulian.rusu@student.tuiasi.ro                            *
 *  Description: Exception that signals that a file extension is not      *
 *               valid in some context.                                   *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/


using System;

namespace Shared
{
    /// <summary>
    /// Exception subclass that is used for invalid file extension.
    /// </summary>
    public class InvalidExtensionException: Exception
    {
        public InvalidExtensionException(string extension) : base($"Invalid extension: {extension}")
        {
           
        }
    }
}
