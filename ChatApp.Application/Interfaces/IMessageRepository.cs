using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Defines persistence operations for chat messages.
/// </summary>
namespace ChatApp.Application.Interfaces
{
    public interface IMessageRepository
    {
        /// Adds a new message to the data store.
        Task AddAsync(Message message);


        /// Retrieves all messages ordered by creation time.
        /// <returns>List of stored messages. 

        Task<List<Message>> GetAllAsync();
    }
}
